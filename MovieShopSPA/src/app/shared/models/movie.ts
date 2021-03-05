import { Genre } from './genre';
import { Cast } from './cast';

export interface Movie {
    id: number;
    title: string;
    overview: string;
    tagline: string;
    budget: number;
    revenue: number;
    imdbUrl: string;
    tmdbUrl: string;
    posterUrl: string;
    backdropUrl: string;
    originalLanguage: string;
    releaseDate: string;
    runTime: number;
    price: number;
    genres: Genre[];
    casts: Cast[];
  }
  
