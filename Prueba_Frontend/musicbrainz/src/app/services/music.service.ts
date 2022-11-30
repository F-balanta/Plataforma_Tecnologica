import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {GenreModel} from "../models/genreModel";


@Injectable({
  providedIn: 'root'
})
export class MusicService {
  /*Url API*/
  apiUrl ="https://musicbrainz.org/ws/2/genre/all?limit=10&offset=10&fmt=json"
  constructor(
    public http: HttpClient
  ) { }

  getAllGenres() : Observable<GenreModel[]>{
    return this.http.get<GenreModel[]>(this.apiUrl);
  }


  getAllGenresWithPagination(limit:number, offset:any) : Observable<GenreModel[]>{
    let params = new HttpParams();
    if(limit && offset)
    {
      params = params.set('limit', limit)
      params = params.set('offset', offset)
    }
    return this.http.get<GenreModel[]>("https://musicbrainz.org/ws/2/genre/all?limit="+limit+"&offset="+offset[1]+"&fmt=json");
  }

}
