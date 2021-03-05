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
  
interface Cast {
    id: number;
    name: string;
    gender: string;
    tmdbUrl?: any;
    profilePath: string;
    character: string;
  }

  interface Genre {
    id: number;
    name: string;
  }
