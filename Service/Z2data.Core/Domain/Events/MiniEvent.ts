declare module server {
	interface MiniEvent {
		code: string;
        category: string;
        type: string;
        startDate?: Date;
        lastUpdated?: Date;
        title: string;
        country: string;
        state: string;
        city: string;
        severity: string;
        status:string;

    }
}
