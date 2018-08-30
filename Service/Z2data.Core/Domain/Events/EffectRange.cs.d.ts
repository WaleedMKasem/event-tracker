declare module server {
	interface EffectRange {
		/** Event Georgaphical Place */
		affectedRadius?: number;
		nearRadius?: number;
		location: server.Location;
	}
}
