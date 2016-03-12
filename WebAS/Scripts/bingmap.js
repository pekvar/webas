var map = null, infobox, dataLayer;
var resources = {}; // Global variable.


$(document).ready(function () {
    getResources();

    Microsoft.Maps.loadModule('Microsoft.Maps.Themes.BingTheme', { callback: GetMap });

    function GetMap() {
        // Initialize the map
        map = new Microsoft.Maps.Map(
               document.getElementById('myMap'),
               {
                   theme: new Microsoft.Maps.Themes.BingTheme(),
                   credentials: "AqSlfjBjSoHeAzY1C8AeQFCnOLuk9UnDteg7Jw-cS_JROtMMBZnPxLlmyXWUl9Iu",
                   center: new Microsoft.Maps.Location(66.383301, 23.6667),
                   mapTypeId: Microsoft.Maps.MapTypeId.road,
                   showMapTypeSelector: true,
                   ShowScaleBar: true,
                   ShowNavigationBar: true,
                   enableClickableLogo: false,
                   enableSearchLogo: false,
                   zoom: 12,
                   showBreadcrumb: true,
                   customizeOverlays: true
               });

        addLayers();

        Microsoft.Maps.Events.addHandler(map, 'click', addPin);

        // Hide the infobox when the map is moved.
        Microsoft.Maps.Events.addHandler(map, 'viewchange', hideInfobox);

        getLocations();
    }

    function getResources() {
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: "/Resource/GetResources",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $.each(data, function (index, stringText) {
                    resources[index] = stringText;
                });
            },
            failure: function (failureMsg) {
                alert("Failure getResources: " + failuremsg);
            },
            error: function (errMsg) {
                alert("Error getResources: " + errMsg);
            }
        });
    }

    function clearLayers() {
        map.entities.clear();
    }

    function addLayers() {
        dataLayer = new Microsoft.Maps.EntityCollection();
        map.entities.push(dataLayer);

        var infoboxLayer = new Microsoft.Maps.EntityCollection();
        map.entities.push(infoboxLayer);

        infobox = new Microsoft.Maps.Infobox(new Microsoft.Maps.Location(0, 0), { visible: false, offset: new Microsoft.Maps.Point(0, 20) });
        infoboxLayer.push(infobox);
    }

    function getLocations() {
        // Method 2
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: "/Location/GetLocations",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $.each(data, function (index, LocationData) {
                    AddData(LocationData);
                });
            },
            failure: function (failureMsg) {
                alert("Failure:" + failuremsg);
            },
            error: function (errMsg) {
                alert("Error:" + errMsg);
            }
        });
    }

    function getLocation(id) {
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: "/Location/GetLocation/" + id,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                AddData(data);
            },
            failure: function (failureMsg) {
                alert("Failure:" + failuremsg);
            },
            error: function (errMsg) {
                alert("Error:" + errMsg);
            }
        });
    }

    function addPin(e) {
        if (e.targetType === "map") {
            var point = new Microsoft.Maps.Point(e.getX(), e.getY());
            var loc = e.target.tryPixelToLocation(point);

            var pushpinOptions = {
                draggable: true,
                visible: true,
                state: Microsoft.Maps.EntityState.highlighted
            };

            var pin = new Microsoft.Maps.Pushpin(loc, pushpinOptions);

            pin.setOptions(pushpinOptions);
            pin.Title = 'Title';
            pin.text = '0';

            var tmpStr = {
                LocationId: 0,
                Latitude: loc.latitude,
                Longitude: loc.longitude,
                Altitude: 0,
                Title: 'Title',
                Description: 'Description'
            }

            pin.Description = JSON.stringify(tmpStr);

            var html = '<div class="infoboxText" id="infoboxText">';
            html = html + '<table class="table table-condensed">';
            html = html + '<tr><th>' + resources["LabelLocationId"] + '</th><td>' + '</td></tr>';
            html = html + '<tr><th>' + resources["LabelTitle"] + '</th><td>' + '</td></tr>';
            html = html + '<tr><th>' + resources["LabelDescription"] + '</th><td>' + '</td></tr>';
            html = html + '<tr><th>' + resources["LabelLatitude"] + '</th><td>' + tmpStr.Latitude + '</td></tr>';
            html = html + '<tr><th>' + resources["LabelLongitude"] + '</th><td>' + tmpStr.Longitude + '</td></tr>';
            html = html + '<tr><th>' + resources["LabelAltitude"] + '</th><td>' + tmpStr.Altitude + '</td></tr>';
            html = html + '<tr><th></th>';
            html = html + '<td>';
            html = html + '<div class="infoboxLink">';
            html = html + '<a href="/Location/Create/?Latitude=' + tmpStr.Latitude + '&Longitude=' + tmpStr.Longitude + '&Altitude=' + tmpStr.Altitude + '">' + resources["Create"] + '</a>';
            html = html + '</div>';
            html = html + '</td></tr>';
            html = html + '</table>';
            html = html + '</div>';

            infobox.setLocation(loc);
            infobox.setOptions(
                {
                    visible: true,
                    showPointer: true,
                    offset: new Microsoft.Maps.Point(0, 15),
                    htmlContent: html
                });

            Microsoft.Maps.Events.addHandler(pin, 'click', showInfobox);

            //dataLayer.push(pin);
            //dataLayer.push(infobox)
        }

        return false;
    }

    function removePin(e) {
        if (e.targetType === 'pushpin') {

            var indexOfPinToRemove = dataLayer.indexOf(e.target);
            // Remove  eventhandler rightclick from pin
            if (Microsoft.Maps.Events.hasHandler(indexOfPinToRemove, 'rightclick')) {
                Microsoft.Maps.Events.removeHandler(indexOfPinToRemove.rightclick);
            }

            dataLayer.removeAt(indexOfPinToRemove);
        }
    }

    function AddData(locationData) {

        var pushpinOptions = {
            draggable: true,
            visible: true,
            text: locationData.LocationId,
            state: Microsoft.Maps.EntityState.highlighted
        };

        var pin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(locationData.Latitude, locationData.Longitude));

        pin.setOptions(pushpinOptions);
        pin.Title = locationData.Title;
        pin.Description = JSON.stringify(locationData);

        // Create the infobox for the pushpin
        infobox = new Microsoft.Maps.Infobox(pin.getLocation(),
            {
                //id: locationData.LocationId,
                visible: false,
                showCloseButton: true,
                offset: new Microsoft.Maps.Point(10, 20)
            });

        //Microsoft.Maps.Events.addHandler(pin, 'rightclick', removePin);
        Microsoft.Maps.Events.addHandler(pin, 'click', showInfobox);

        dataLayer.push(pin);
        dataLayer.push(infobox);
    }

    function showInfobox(e) {

        var parameters = JSON.parse(e.target.Description);

        var html = '<div class="infoboxText">'
        html = html + '<table class="table table-condensed">';
        html = html + '<tr><th>' + resources["LabelLocationId"] + '</th><td>' + parameters.LocationId + '</td></tr>';
        html = html + '<tr><th>' + resources["LabelTitle"] + '</th><td>' + parameters.Title + '</td></tr>';
        html = html + '<tr><th>' + resources["LabelDescription"] + '</th><td>' + parameters.Description + '</td></tr>';
        html = html + '<tr><th>' + resources["LabelLatitude"] + '</th><td>' + parameters.Latitude + '</td></tr>';
        html = html + '<tr><th>' + resources["LabelLongitude"] + '</th><td>' + parameters.Longitude + '</td></tr>';
        html = html + '<tr><th>' + resources["LabelAltitude"] + '</th><td>' + parameters.Altitude + '</td></tr>';
        html = html + '<tr><th></th>';
        html = html + '<td>';
        html = html + '<div class="infoboxLink">';
        html = html + '<a href="/Location/Edit/' + parameters.LocationId + '">' + resources["Edit"] + '</a>';
        html = html + '<a href="/Location/Details/' + parameters.LocationId + '">' + resources["Details"] + '</a>';
        html = html + '<a href="/Location/Delete/' + parameters.LocationId + '">' + resources["Delete"] + '</a>';
        html = html + '</div>';
        html = html + '</td>';
        html = html + '</tr>';
        html = html + '</table>';

        html = html + '</div>';

        if (e.targetType == 'pushpin') {

            infobox.setLocation(e.target.getLocation());
            infobox.setOptions(
                {
                    visible: true,
                    showPointer: true,
                    offset: new Microsoft.Maps.Point(0, 15),
                    htmlContent: html
                });
        }
    }

    function hideInfobox(e) {
        infobox.setOptions({ visible: false });
    }

    function DisplayLoc(e) {
        e.handled = true;
        if (e.targetType == 'pushpin') {

            var pinLoc = e.target.getLocation();
            alert("The location of the pushpin is now " + pinLoc.latitude + ", " + pinLoc.longitude);
        }
    }

    $('#btnRefreshMap').click(function () {
        clearLayers();
        addLayers();
        getLocations();
        //getLocation(2);
    });

});
