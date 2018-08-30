import { Country } from '../../lookups/country';
import { City } from '../../lookups/city';
export interface Place {
    country: Country;
    state: {
        stateId: number;
        name: string;
    };
    city: City;
    other: string;
}
