import { Photo } from "./photo";

export interface Member {
    id: number;
    userName: string;
    age: number;
    photoUrl: string;
    knownAs: string;
    created: Date;
<<<<<<< HEAD
    lastACtive: Date;
=======
    lastActive: Date;
>>>>>>> datingapp/main
    gender: string;
    introduction: string;
    interests: string;
    lookingFor: string;
    city: string;
    country: string;
    photos: Photo[];
}
<<<<<<< HEAD

=======
>>>>>>> datingapp/main
