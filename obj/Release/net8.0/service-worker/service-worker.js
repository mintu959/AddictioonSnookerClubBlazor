// Blazor PWA Service Worker
self.addEventListener('install', async event => {
    event.waitUntil(
        caches.open('addictioon-v1').then(cache =>
            cache.addAll(['/', '/index.html', '/css/app.css'])
        )
    );
});

self.addEventListener('fetch', event => {
    event.respondWith(
        caches.match(event.request)
            .then(r => r || fetch(event.request))
    );
});
/* Manifest version: 4Sl6yOoq */
