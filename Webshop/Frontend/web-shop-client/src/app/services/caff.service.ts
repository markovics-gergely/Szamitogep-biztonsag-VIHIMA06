import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CaffDetailViewModel, CaffViewModel, CommentCreateDTO, CommentViewModel, PagerList, RemoveCommentDTO } from 'models';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CaffService {
  /** Base url of caff endpoint */
  private _baseUrl = `${environment.baseUrl}/caff`;

  constructor(private http: HttpClient) { }

  /**
   * Send get request for caffs for the browse page
   * @returns List of caffs data for browse page
   */
  public getCaffs(
    pageSize: number,
    pageCount: number,
    search?: string,
  ): Observable<PagerList<CaffViewModel>> {
    return of({
      values: [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa5",
          "price": 0,
          "title": "stringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstring",
          "coverUrl": "https://via.placeholder.com/300x300.png?text=Caff",
          "uploader": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "userName": "string"
          }
        },
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "price": 0,
          "title": "string",
          "coverUrl": "https://via.placeholder.com/300x300.png?text=Caff",
          "uploader": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "userName": "string"
          }
        }
      ],
      total: 2
    });
    /** TODO mock */
    return this.http.get<PagerList<CaffViewModel>>(this._baseUrl, {
      params: new HttpParams()
        .set('Search', search || '')
        .set('PageSize', pageSize)
        .set('PageCount', pageCount),
    });
  }

  /**
   * Send get request for caff details
   * @returns Caff with detailed informations
   */
  public getCaff(caffId: string): Observable<CaffDetailViewModel> {
    return of({
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "price": 0,
      "title": "string",
      "description": "string",
      "coverUrl": "https://via.placeholder.com/300x300.png?text=Caff",
      "uploader": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "userName": "string"
      }
    });
    /** TODO mock */
    return this.http.get<CaffDetailViewModel>(`${this._baseUrl}/${caffId}`);
  }

  public getComments(caffId: string): Observable<CommentViewModel[]> {
    return of([
      {
        userName: "Admin",
        text: "asdasdas"
      },
      {
        userName: "Admin",
        text: "asdasdas"
      },
      {
        userName: "Admin",
        text: "asdasdas"
      },
      {
        userName: "Admin",
        text: "asdasdas"
      },
      {
        userName: "Admin",
        text: "asdasdas"
      },
      {
        userName: "Admin",
        text: "asdasdas"
      },
    ]);
  }

  public deleteCaff(id: string): Observable<any> {
    return of(undefined);
    // TODO mock
    return this.http.delete(`${this._baseUrl}/${id}`);
  }

  public addToCart(id: string): Observable<any> {
    return of(undefined);
    // TODO mock
    return this.http.post(`${this._baseUrl}/checkout/${id}`, {});
  }

  public downloadCaff(id: string): Observable<any> {
    return of(undefined);
    // TODO mock
    return this.http.post(`${this._baseUrl}/download/${id}`, {});
  }

  public createComment(id: string, dto: CommentCreateDTO): Observable<any> {
    return of(undefined);
    // TODO mock
    return this.http.post(`${this._baseUrl}/${id}/comments/add`, this.getFormData(dto));
  }

  public deleteComment(id: string, dto: RemoveCommentDTO): Observable<any> {
    return of(undefined);
    // TODO mock
    return this.http.put(`${this._baseUrl}/${id}/comments/remove`, this.getFormData(dto));
  }

  public removeFromCart(id: string): Observable<any> {
    return of(undefined);
    // TODO mock
  }

  /**
   * Generate form data from object
   * @param obj Object to transform
   * @returns FormData generated
   */
  private getFormData(obj: any): FormData {
    return Object.keys(obj).reduce((formData, key) => {
      formData.append(key, obj[key]);
      return formData;
    }, new FormData());
  }
}
