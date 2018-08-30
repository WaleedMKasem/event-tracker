declare module server {
	interface AssociatedEvent {
		category: server.Lookup;
		type: server.Lookup;
		severity: server.Severity;
		effectRange: {
		/** Event Georgaphical Place */
			affectedRadius?: number;
			nearRadius?: number;
			location: server.Location;
		};
	}
}
