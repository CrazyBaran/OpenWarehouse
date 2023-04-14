import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  StorageUnitDto,
  StorageUnitResultRequestDto,
} from '@proxy/inventory/application/contracts/storages';
import { StorageUnitService } from '@proxy/inventory/application/storages';

@Component({
  selector: 'app-storages',
  templateUrl: './storages.component.html',
  styleUrls: ['./storages.component.scss'],
  providers: [ListService],
})
export class StoragesComponent implements OnInit {
  storages = { items: [], totalCount: 0 } as PagedResultDto<StorageUnitDto>;
  storageUnitRequestParams = { depth: 1 } as StorageUnitResultRequestDto;
  isModalOpen = false;
  form: FormGroup;

  constructor(
    public readonly list: ListService<StorageUnitResultRequestDto>,
    private router: Router,
    private route: ActivatedRoute,
    private storageUnitService: StorageUnitService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.storageUnitRequestParams.depth = params['depth'] ?? 1;
      this.storageUnitRequestParams.parentStorageUnitHierarchyId =
        params['parentStorageUnitHierarchyId'];
    });
    const storageStreamCreator = query => {
      var fullQuery = { ...query, ...this.storageUnitRequestParams };
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: fullQuery,
        queryParamsHandling: 'merge',
      });
      return this.storageUnitService.getList(fullQuery);
    };

    this.list.hookToQuery(storageStreamCreator).subscribe(response => {
      this.storages = response;
    });
  }

  storageUnitRequestParamsChange(value): void {
    this.list.get();
  }

  createStorageUnit() {
    this.buildForm();
    this.isModalOpen = true;
  }

  buildForm() {
    this.form = this.fb.group({
      displayName: ['', [Validators.required, Validators.minLength(4)]],
      parentStorageUnitHierarchyId: [this.storageUnitRequestParams.parentStorageUnitHierarchyId],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    this.storageUnitService.create(this.form.value).subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

  goToChilds(hierarchyId: string) {
    this.storageUnitRequestParams.parentStorageUnitHierarchyId = hierarchyId;
    this.list.get();
  }

  returnToRoot() {
    this.storageUnitRequestParams.parentStorageUnitHierarchyId = undefined;
    this.list.get();
  }

  returnToParent() {
    var hierarchyId = this.storageUnitRequestParams.parentStorageUnitHierarchyId;
    hierarchyId = hierarchyId.slice(0, -1);
    hierarchyId = hierarchyId.substring(0, hierarchyId.lastIndexOf('/') + 1);
    this.storageUnitRequestParams.parentStorageUnitHierarchyId = hierarchyId;
    this.list.get();
  }
}
