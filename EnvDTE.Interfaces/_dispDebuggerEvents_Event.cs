﻿namespace EnvDTE
{
    public interface _dispDebuggerEvents_Event
    {
        event _dispDebuggerEvents_OnEnterRunModeEventHandler OnEnterRunMode;
        event _dispDebuggerEvents_OnEnterDesignModeEventHandler OnEnterDesignMode;
        event _dispDebuggerEvents_OnEnterBreakModeEventHandler OnEnterBreakMode;
        event _dispDebuggerEvents_OnExceptionThrownEventHandler OnExceptionThrown;
        event _dispDebuggerEvents_OnExceptionNotHandledEventHandler OnExceptionNotHandled;
        event _dispDebuggerEvents_OnContextChangedEventHandler OnContextChanged;
    }
}
