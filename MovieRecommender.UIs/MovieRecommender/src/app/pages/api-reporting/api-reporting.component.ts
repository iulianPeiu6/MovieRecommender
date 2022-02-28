import { CommonModule } from '@angular/common';
import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { DxButtonModule, DxCheckBoxModule, DxDataGridModule, DxLoadIndicatorModule, DxLoadPanelModule, DxSelectBoxModule, DxTextAreaModule } from 'devextreme-angular';
import ArrayStore from 'devextreme/data/array_store';
import 'devextreme/data/odata/store';
import { APIReportingService, APIRequest, Report } from 'src/app/shared/services/api-reporting.service';

@Component({
  templateUrl: 'api-reporting.component.html'
})

export class APIReportingComponent {
  dataSource: any;
  report: Report | undefined;
  loadingVisible = false;

  constructor(private apiReportingService: APIReportingService) {
    this.loadingVisible = true;
    this.dataSource =  new ArrayStore({
      key: ["id"],
      data: new Array<APIRequest>()
    });
  }

  async ngOnInit() {
    this.loadingVisible = true;
    this.report = await this.apiReportingService.getReport();

    this.dataSource =  new ArrayStore({
      key: ["id"],
      data: this.report.apiRequests
    });
    this.loadingVisible = false;
  }
}

@NgModule({
  imports: [
    CommonModule,
    DxLoadIndicatorModule,
    DxLoadPanelModule, 
    DxDataGridModule,
    RouterModule,
    DxButtonModule,
    DxLoadIndicatorModule,
    BrowserModule,
    DxTextAreaModule,
    DxCheckBoxModule,
    DxSelectBoxModule],
  exports: [APIReportingComponent],
  declarations: [APIReportingComponent],
  providers: [],
})
export class APIReportingModule { }
