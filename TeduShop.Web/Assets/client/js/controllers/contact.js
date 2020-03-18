var contact = {
    init: function () {
        contact.registerEvent();
    },
    registerEvent: function () {
        contact.initMap();
    },
    initMap: function () {
        var binhanh = { lat: parseFloat($('#hidLat').val()), lng: parseFloat($('#hidLng').val()) };
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 17,
            center: binhanh
        });

        var contentString = $('#hidAddress').val();

        var infowindow = new google.maps.InfoWindow({
            content: contentString
        });

        var marker = new google.maps.Marker({
            position: binhanh,
            map: map,
            title: $('#hidName').val()
        });

        // Hiển thị ngay thông tin của Marker khi load map mà ko cần click vào Marker
        infowindow.open(map, marker);

        marker.addListener('click', function () {
            infowindow.open(map, marker);
        })
    }
}

contact.init();