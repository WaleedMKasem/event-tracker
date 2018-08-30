declare module server {
	interface EventDetails {
		category: server.Lookup;
		type: server.Lookup;
		startDate?: Date;
		title: string;
		description: string;
		sources: server.Source[];
		images: server.MiniAttachment[];
		attachments: server.MiniAttachment[];
		severity: server.Severity;
		status: server.Status;
		statusPercentage?: number;
		closeDate?: Date;
		closeNotes: string;
	}
}
