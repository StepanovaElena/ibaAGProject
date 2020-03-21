import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Permissions} from '../components/interfases';
import {map} from 'rxjs/operators';
import {environment} from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  private url = "/api/permissions"

  constructor(private http: HttpClient) {
  }

  getAllPermissions(): Observable<Permissions[]> {
    return this.http.get(`${this.url}`)
      .pipe(map((response: { [key: string]: any }) => {
        return Object
          .keys(response)
          .map(key => ({
            ...response[key]
          }));
      }));
  }
}
