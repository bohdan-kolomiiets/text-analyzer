import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TextDataService } from '../../services/text-data.service';
import { Data } from '../../models/data';
import { QueryResult } from '../../../shared/models/query-result';

@Component({
  selector: 'app-data-list',
  templateUrl: './data-list.component.html',
  styleUrls: ['./data-list.component.css']
})
export class DataListComponent implements OnInit {

  dataList: Data[] = [];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private textDataService: TextDataService) {

   }

  ngOnInit() {
    this.textDataService.getList(null, null,"").subscribe( (res: QueryResult<Data>) => {
      this.dataList = res.items;
    });
  }

}
