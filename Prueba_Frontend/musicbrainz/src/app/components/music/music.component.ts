import { Component, OnInit, ViewChild} from '@angular/core';
import {MusicService} from "../../services/music.service";
import {MatPaginator} from '@angular/material/paginator';
import {Genre, GenreModel} from "../../models/genreModel";

@Component({
  selector: 'app-music',
  templateUrl: './music.component.html',
  styleUrls: ['./music.component.scss']
})
export class MusicComponent implements OnInit {
  public dataTable: any = [];

  page:number = 1;
  count:number = 0;
  tableSize:number = 10;
  tableSizes = [10, 20, 50, 100];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private _musicService : MusicService
  ) {}

  ngOnInit(): void {
    this.fetchGenres();
  }


  // This method will be called for consume the service (MusicService)
  fetchGenres(){
    this._musicService.getAllGenresWithPagination(this.tableSize, this.tableSizes)
      .subscribe((response) =>{
        this.dataTable = response;
        console.log(this.dataTable);
      },error => console.log(error));
  }

  onTableDataChange(event:any){
    this.page = event;
    this.fetchGenres();
  }

  onDataTableSizeChange(event:any):void{
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchGenres()
  }

}
