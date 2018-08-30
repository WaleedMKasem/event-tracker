import { DisasterUnit } from '../../shared/enums/disaster-unit';
export interface EventFeature {
		/** (Magnitude) */
		value?: number;
		unit: DisasterUnit;
		/** (Human) */
		populationAffected?: number;
		populationDeaths?: number;
		populationMissing?: number;
		/** (Properties) */
		acresBurned?: number;
		damageInMillionUsd?: number;
		damageInProperty: string;
		insuredLosses?: number;
		notes: string;
}
