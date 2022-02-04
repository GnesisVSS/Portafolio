var CACHE_NAME = 'cache1';
var urlsToCache = [
    '/'
];

self.addEventListener('install', function (event) {
    event.waitUntil(
        caches.open(CACHE_NAME)
            .then(function (cache) {
                console.log('Opened cache');
                return cache.addAll(urlsToCache);
            })
    );
});

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request).then(function (response) {
            return fetch(event.request)
                .catch(function (rsp) {
                    return response;
                });
        })
    );
});


//notificaciones


importScripts("https://www.gstatic.com/firebasejs/3.9.0/firebase-app.js")
importScripts("https://www.gstatic.com/firebasejs/3.9.0/firebase-messaging.js")

const firebaseConfig = {
    apiKey: "AIzaSyBggk_9rw22cs0v7h4r91G5BO8V1oxTJxQ",
    authDomain: "nomasaccidentes-c8253.firebaseapp.com",
    projectId: "nomasaccidentes-c8253",
    storageBucket: "nomasaccidentes-c8253.appspot.com",
    messagingSenderId: "1082116732737",
    appId: "1:1082116732737:web:cbe7b92afd63649c3ed3c0"
};

firebase.initializeApp(firebaseConfig);

let messaging = firebase.messaging();

messaging.setBackgroundMessageHandler(function (payload) {

    let title = 'Titulo Notificacion';

    let options = {
        body: "Mensaje",
        icon: 'static/img/Isotipo.png',
    }

    self.registration.showNotificaction(title, options);


});
