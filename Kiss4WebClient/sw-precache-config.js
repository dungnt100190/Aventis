module.exports = {
  navigateFallback: '/index.html',
  stripPrefix: './dist',
  root: './dist/',
  staticFileGlobs: [
    './dist/index.html',
    './dist/**.js',
    './dist/**.css',
    './dist/**.ttf',
    './dist/assets/images/*',
    './dist/assets/webdav/**.js',
    './dist/config/*',
    './dist/i18n/en.json',
    './dist/i18n/de.json',
    './dist/i18n/fr.json',
    './dist/i18n/it.json',
  ],
  runtimeCaching: [{
    urlPattern: '',
    handler: 'fastest'
  }]
};