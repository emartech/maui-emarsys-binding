package com.emarsys.maui;

import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import com.emarsys.mobileengage.api.geofence.Geofence;
import com.emarsys.mobileengage.api.geofence.Trigger;
import java.util.ArrayList;
import java.util.List;

public class DotnetEmarsysGeofence {

    public static void setInitialEnterTriggerEnabled(boolean initialEnterTriggerEnabled) {
        Emarsys.getGeofence().setInitialEnterTriggerEnabled(initialEnterTriggerEnabled);
    }

    public static void enable(@NonNull CompletionListener completionListener) {
        Emarsys.getGeofence().enable(completionListener::onCompleted);
    }

    public static void disable() {
        Emarsys.getGeofence().disable();
    }

    public static boolean isEnabled() {
        return Emarsys.getGeofence().isEnabled();
    }

    public static void setEventHandler(@NonNull EventHandler eventHandler) {
        Emarsys.getGeofence().setEventHandler(eventHandler::handleEvent);
    }

    public static @NonNull List<EMSGeofence> getRegisteredGeofences() {
        List<Geofence> geofences = Emarsys.getGeofence().getRegisteredGeofences();
        return mapGeofences(geofences);
    }

    static @NonNull List<EMSGeofence> mapGeofences(@NonNull List<Geofence> geofences) {
        List<EMSGeofence> _geofences = new ArrayList<>();
        for (int i = 0; i < geofences.size(); i++) {
            Geofence g = geofences.get(i);
            List<EMSGeofenceTrigger> triggers = new ArrayList<>();
            for (int j = 0; j < g.getTriggers().size(); j++) {
                Trigger t = g.getTriggers().get(j);
                triggers.add(new EMSGeofenceTrigger(t.getId(), t.getType().toString(), t.getLoiteringDelay(), t.getAction()));
            }
            _geofences.add(new EMSGeofence(g.getId(), g.getLat(), g.getLon(), g.getRadius(), g.getWaitInterval(), triggers));
        }
        return _geofences;
    }

}
