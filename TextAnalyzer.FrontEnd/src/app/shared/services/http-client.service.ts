import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Injectable()
export class HttpClient {
  siteRootUrl: string = environment.originUrl;

  constructor(private http: Http) { }

  createAuthorizationHeader(headers: Headers) {
    headers.set('Content-type', 'application/json');
    // headers.set('Accept', '*/*');
    headers.set('Access-Control-Allow-Origin', '*');
  }

  get(url) {
    let headers = new Headers();
    this.createAuthorizationHeader(headers);
    return this.http.get(this.normalizeUrl(url), {
      headers: headers
    });
  }

  post(url, data) {
    let headers = new Headers();
    this.createAuthorizationHeader(headers);
    return this.http.post(this.normalizeUrl(url), data, {
      headers: headers
    });
  }

  put(url, data) {
    let headers = new Headers();
    this.createAuthorizationHeader(headers);
    return this.http.put(this.normalizeUrl(url), data, {
      headers: headers
    });
  }

  delete(url) {
    let headers = new Headers();
    this.createAuthorizationHeader(headers);
    return this.http.delete(this.normalizeUrl(url), {
      headers: headers
    });
  }

  private normalizeUrl(url: string): string {
    if (url.startsWith('https://') || url.startsWith('http://') || url.startsWith('www')) {
      return url;
    };
    if (url[0] === '/') {
      return this.siteRootUrl + url;
    } else {
      return this.siteRootUrl + '/' + url;
    }
  }
}