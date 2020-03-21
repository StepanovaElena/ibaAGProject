import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {Group} from '../components/interfases';
import {map, catchError} from 'rxjs/operators';
import {HttpClient} from '@angular/common/http';
import {AlertService} from './alert.service';
import { error } from 'util';

export type GroupEmitType = 'create' | 'delete';

export interface GroupEmit {
  type: GroupEmitType;
  group: Group;
}

@Injectable({
  providedIn: 'root'
})
export class GroupService {

  public groupActions$ = new Subject<GroupEmit>();

  private url = "/api/groups";

  constructor(private http: HttpClient, private alert: AlertService) {
  }

  getAllGroups(): Observable<Group[]> {
    return this.http.get(`${this.url}`)
      .pipe(map((response: { [key: string]: any }) => {
        if (response) {
          return Object
            .keys(response)
            .map(key => ({
              ...response[key]
            }));
        } else {
          return;
        }
      }));
  }

  create(group: Group): Observable<{ id: string }> {
    return this.http.post(`${this.url}`, group)
      .pipe(map((response : string) => {
        this.groupActions$.next({
          type: 'create',
          group: {
            ...group,
            id: response
          }
        });
        return {id: response};
      }));
  }

  update(group: Group): Observable<Group> {
    return this.http.put<Group>(`${this.url}/${group.id}`, group);
  }

  delete(group: Group): Observable<void> {    
    return this.http.delete(`${this.url}/${group.id}`)
      .pipe(map((response: { [key: string]: any }) => {
        if (!response['errorText']) {
            this.groupActions$.next({type: 'delete', group});
        }
      }));
  }

  getGroupsById(id: string): Observable<Group> {
    return this.http.get<Group>(`${this.url}/${id}`)
      .pipe(map((group: Group) => {
        return group
      }));
  }

  getGroupByName(name: string): Observable<{ name: any }[]> {
    return this.http.get<Group>(`${this.url}/${name}`)
      .pipe(map((response: { [key: string]: any }) => {
        return Object
          .keys(response)
          .map(key => ({
            name: response[key].name
          }));
      }));
  }
}
