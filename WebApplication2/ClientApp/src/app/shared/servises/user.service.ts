import {Injectable, OnDestroy} from '@angular/core';
import {Observable, Subject, Subscription} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {EffectivePermissions, Group, User} from '../components/interfases';
import {PermissionService} from './permission.service';
import {AlertService} from './alert.service';


export type UserEmitType = 'create' | 'delete';

export interface UserEmit {
  type: UserEmitType;
  user: User;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public userActions$ = new Subject<UserEmit>();

  private url = "/api/users";

  constructor(private http: HttpClient, private alert: AlertService) {
  }

  create(user: User): Observable<{ id: string }> {
    return this.http.post(`${this.url}`, user)
      .pipe(map((response: string) => {
        this.userActions$.next({
          type: 'create',
          user: {
            ...user,
            id: response
          }
        });
        return {
          id: response
        };
      }));
  }

  update(user: User): Observable<User> {
    return this.http.put<User>(`${this.url}/${user.id}`, user);
  }

  delete(user: User): Observable<void> {   
    return this.http.delete(`${this.url}/${user.id}`)
      .pipe(map((response: { [key: string]: any }) => {
        if (!response['errorText']) {
          this.userActions$.next({ type: 'delete', user });
        }
      }));
  }

  getAllUsers(): Observable<User[]> {
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

  getUserByEmail(email: string): Observable<{ email: any }[]> {
    return this.http.get<User>(`${this.url}/${email}`)
      .pipe(map((response: { [key: string]: any }) => {
        return Object
          .keys(response)
          .map(key => ({
            email: response[key].email
          }));
      }));
  }

  getUserById(id: string): Observable<User> {
    return this.http.get<User>(`${this.url}/${id}`)
      .pipe(map((user: User) => {
        return user;
      }));
  }
}
