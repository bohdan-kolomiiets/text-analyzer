import { HttpClient } from './http-client.service';
import { environment } from './../../../environments/environment';
import { Router } from '@angular/router';
import { NotFoundAppError } from './../../shared/models/infrastructure/not-found-error';
import { UnauthorizedError } from './../../shared/models/infrastructure/unauthorized-error';
import { ResObj } from './../../shared/models/infrastructure/res-obj';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/finally';
// import { Observable } from 'rxjs/Rx';

import { Injectable } from '@angular/core';
import { AppHelpers } from '../app-helpers';
import { AppError } from '../models/infrastructure/app-error';
import { BadInputAppError } from '../models/infrastructure/bad-input-error';
import { Http } from '@angular/http';

@Injectable()
export class DataService {

    protected url: string = environment.originUrl;

    constructor(protected endPoint: string, protected httpClient: HttpClient) {
    }

    public search(name: string, path: string = "") {
        if (path)
            path = "/" + path;
        let fullUrl = `${this.url}${this.endPoint}${path}/search/${name}`;
        console.log(fullUrl);
        return this.httpClient.get(fullUrl)
            .catch(this.handleError).map(res => res.json());
    }

    public get(id, includeInfo?: any, additionalPath?: string) {
        let newEndPoint: string = this.endPoint;
        if (additionalPath)
            newEndPoint += "/" + additionalPath;
        let fullUrl = `${this.url}${newEndPoint}/${id}${AppHelpers.toQueryString(includeInfo)}`;
        console.log(fullUrl);
        return this.httpClient.get(fullUrl)
            .catch(this.handleError).map(res => res.json());
    }

    public getAll(includeInfo?, additionalPath?: string) {

        let newEndPoint: string = this.endPoint;
        if (additionalPath)
            newEndPoint += "/" + additionalPath;
        let fullUrl = `${this.url}${newEndPoint}${AppHelpers.toQueryString(includeInfo)}`;
        console.log(fullUrl);
        return this.httpClient.get(fullUrl)
            .catch(this.handleError).map(res => res.json());
    }

    public getList(query, includeInfo?, additionalPath?: string) {
        let newEndPoint: string = this.endPoint;
        if (additionalPath)
            newEndPoint += "/" + additionalPath;
        let fullUrl = `${this.url}${newEndPoint}${AppHelpers.toQueryString(query)}&${AppHelpers.toQueryString(includeInfo)}`;
        console.log(fullUrl);
        return this.httpClient.get(fullUrl)
            .catch(this.handleError).map(res => res.json());
    }

    public create(object, additionalPath?: string) {
        let newEndPoint: string = this.endPoint;
        if (additionalPath)
            newEndPoint += "/" + additionalPath;
        let fullUrl = `${this.url}${newEndPoint}`;
        console.log(fullUrl);
        return this.httpClient.post(fullUrl, object)
            .catch(this.handleError).map(res => res.json());
    }

    public update(object, additionalPath?: string) {
        let newEndPoint: string = this.endPoint;
        if (additionalPath)
            newEndPoint += "/" + additionalPath;
        let fullUrl = `${this.url}${newEndPoint}`;
        console.log(fullUrl);
        return this.httpClient.put(fullUrl, object)
            .catch(this.handleError).map(res => res.json());
    }

    public delete(id, additionalPath?: string) {
        let newEndPoint: string = this.endPoint;
        if (additionalPath)
            newEndPoint += "/" + additionalPath;
        let fullUrl = `${this.url}${newEndPoint}/${id}`;
        console.log(fullUrl);
        return this.httpClient.delete(fullUrl)
            .catch(this.handleError).map(res => res.json());
    }


    public handleError(error: Response) {
        console.log(error);
        if (error.status === 400)
            return Observable.throw(new BadInputAppError());
        else if (error.status === 401) {
            // this.router.navigate(['/login']);
            return Observable.throw(new UnauthorizedError());
        }
        else if (error.status === 404) {
            // this.router.navigate(['/not-found']);
            return Observable.throw(new NotFoundAppError());
        }
        return Observable.throw(new AppError(error.json()));
    }
}
