import { HttpClient } from './../../shared/services/http-client.service';
import { Http } from '@angular/http';
import { DataService } from './../../shared/services/data.service';
import { Injectable } from '@angular/core';

@Injectable()
export class TextDataService extends DataService {

  constructor(protected http: HttpClient) {
    super("/data", http);
   }

}
