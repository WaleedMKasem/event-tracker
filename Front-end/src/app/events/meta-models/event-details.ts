import { Lookup } from '../../lookups/lookup';
import { Source } from '../../events/meta-models/source';
import { Attachment } from '../../events/meta-models/attachment';
import { Severity } from '../../shared/enums/severity';
import { Status } from '../../shared/enums/status';
export interface EventDetails {
		category: Lookup;
		type: Lookup;
		startDate?: Date;
		title: string;
		description: string;
		sources: Source[];
		images: Attachment[];
		attachments: Attachment[];
		severity: Severity;
		status: Status;
		statusPercentage?: number;
		closeDate?: Date;
		closeNotes: string;
}
