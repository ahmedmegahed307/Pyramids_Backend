using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.Enums
{
    public enum JobActionTypeEnum
    {
        NONE,

        [Description("CREATED")]
        Created,

        [Description("CANCELLED")]
        Cancelled,

        [Description("ASSIGNED")]
        Assigned,

        [Description("CLOSED_ADMIN")]
        ClosedOnAdmin,

        [Description("RESOLVED_MOBILE")]
        ResolvedOnMobile,

        [Description("TRAVEL_STARTED")]
        TravelStarted,

        [Description("TRAVEL_CANCELLED")]
        TravelCancelled,

        [Description("TRAVEL_FINISHED")]
        TravelFinished,

        [Description("WORK_STARTED")]
        WorkStarted,

        [Description("WORK_STOPPED")]
        WorkStopped,

        [Description("TRAVELBACK_STARTED")]
        TravelBackStarted,

        [Description("TRAVELBACK_CANCELLED")]
        TravelBackCancelled,

        [Description("TRAVELBACK_FINISHED")]
        TravelBackFinished,

        [Description("PHOTO_ADDED")]
        PhotoAdded,

        [Description("PHOTO_DELETED")]
        PhotoDeleted,

        [Description("SIGN_CLIENT_ADDED")]
        SignatureClientAdded,

        [Description("SIGN_ENG_ADDED")]
        SignatureEngineerAdded,

        [Description("SIGN_CLIENT_DELETED")]
        SignatureClientDeleted,

        [Description("SIGN_ENG_DELETED")]
        SignatureEngineerDeleted,

        [Description("PART_ADDED")]
        PartAdded,

        [Description("PART_DELETED")]
        PartDeleted,

        [Description("SAVED")]
        Saved,

        [Description("SEND_BACK_TO_ASSIGN")]
        SendBackToAssigned,

        [Description("SEND_BACK_TO_OPEN")]
        SendBackToOpen,

        [Description("RESOLVED_ADMIN")]
        ResolvedOnAdmin,

        [Description("EDIT_JOB")]
        JobEdited,

        [Description("ATTACHMENT_ADDED")]
        AttachmentAdded,

        [Description("ATTACHMENT_DELETED")]
        AttachmentDeleted,

        [Description("SAVED_ON_MOBILE")]
        SavedOnMobile,

        [Description("CREATED_MOBILE")]
        CreatedMobile,

        [Description("ASSIGNED_MOBILE")]
        AssignedMobile,

        [Description("NONE")]
        None2,

        [Description("ADD_PAYMENT")]
        AddPayment,

        [Description("UPDATE_PAYMENT")]
        UpdatePayment,

        [Description("PENDING_REQUEST")]
        PendingRequest,

        [Description("WORK_REMOTE")]
        WorkRemote,

        [Description("STOP_REMOTE")]
        StopRemote,

        [Description("CLOSE_REMOTE")]
        CloseRemote,
    }
}
