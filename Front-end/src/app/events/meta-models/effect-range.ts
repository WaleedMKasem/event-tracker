import { Location } from '../../lookups/location'
export interface EffectRange {
		/** Event Georgaphical Place */
		affectedRadius?: number;
		nearRadius?: number;
		location: Location;
}
