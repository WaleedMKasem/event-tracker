declare module server {
	interface EventFeature {
		/** (Magnitude) */
		value?: number;
		unit: server.DisasterUnit;
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
}
