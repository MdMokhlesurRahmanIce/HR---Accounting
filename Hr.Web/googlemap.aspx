<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="googlemap.aspx.cs" Inherits="ST.Infrastructure.googlemap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <style type="text/css">
        html
        {
            height: 100%;
        }
        body
        {
            height: 100%;
            margin: 0 auto;
            padding: 0px 250px;
            text-align:center;
        }
    </style>
    <title>Google Maps JavaScript API v3 Example</title>

    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>

    <script type="text/javascript">
        var geocoder;
        var map;
        var markersArray = [];
        var marker;
        var infowindow = new google.maps.InfoWindow();

        function initialize() {
            geocoder = new google.maps.Geocoder();
            var myOptions = {
                zoom: 8,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }
            map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

            codeAddress();

            google.maps.event.addListener(map, 'click', function (event) {

                placeMarker(event.latLng);
            });

        }

        function codeAddress() {
            var address = document.getElementById("address").value;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    clearOverlays();

                    document.getElementById("address").value = results[0]['formatted_address'];
                    document.getElementById("latlong").innerText = results[0].geometry.location;
                    map.setCenter(results[0].geometry.location);
                    marker = new google.maps.Marker({
                        map: map,
                        title: results[0]['formatted_address'],
                        position: results[0].geometry.location,
                        animation: google.maps.Animation.DROP
                    });

                    infowindow.setContent(results[1].formatted_address);
                    infowindow.open(map, marker);

                    markersArray.push(marker);

                } else {
                    alert("Geocode was not successful for the following reason: " + status);
                }
            });
        }

        function placeMarker(location) {

            geocoder.geocode({ 'latLng': location }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        clearOverlays();

                        document.getElementById("address").value = results[1].formatted_address;
                        document.getElementById("latlong").innerText = results[0].geometry.location;
                        marker = new google.maps.Marker({
                            position: location,
                            title: results[1].formatted_address,
                            map: map,
                            animation: google.maps.Animation.DROP
                        });
                        infowindow.setContent(results[1].formatted_address);
                        infowindow.open(map, marker);

                        markersArray.push(marker);

                        google.maps.event.addListener(marker, 'click', toggleBounce);

                        map.setCenter(location);

                    }
                } else {
                    alert("Geocoder failed due to: " + status);
                }
            });
        }

        function clearOverlays() {
            if (markersArray) {
                for (i in markersArray) {
                    markersArray[i].setMap(null);
                }
            }
        }

        function toggleBounce() {

            if (marker.getAnimation() != null) {
                marker.setAnimation(null);
            } else {
                marker.setAnimation(google.maps.Animation.BOUNCE);
            }
        }
        
    </script>
<script type="text/javascript">

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-20626488-1']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script>
</head>
<body onload="initialize()" >
    <table width="800px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td colspan="2" align="center">
                <h2>Map My Address</h2>

            </td>
        </tr>
        <tr>
            <td valign="top" style="width:200px;" >
                <table width="100%" cellpadding="0" cellspacing="0" border="0" >
                    <tr>
                        <td align='left'>
                            If you have address please enter it below and click "Show" button.<br />

                            Otherwise use the map to find the address you want. Just click at any point on the map to find its address.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address
                        </td>
                    </tr>
                    <tr>
                        <td>

                             <textarea id="address" rows="5" >Dkaha, Bangladesh</textarea>
                            <input type="button" value="Show" onclick="codeAddress()">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Latitude/Longitude
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <span id="latlong"></span>
                        </td>
                    </tr>
                </table>
                
            </td>
            <td>
                <div id="map_canvas" style="height:500px; width:500px;" >

                </div>
            </td>
        </tr>
    </table>
</body>
</html>

