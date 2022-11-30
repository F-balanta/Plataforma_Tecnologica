export interface Genre {
  id: string;
  name: string;
  disambiguation: string;

  }
export interface GenreModel {
  "genre-offset": number,
  "genre-count": number,
  genres: Genre[];
  }

export interface Iproduct {
  id:number;
  tittle:string;
  price:number;
}
