var gulp = require('gulp');
var typescript = require('gulp-typescript');
var sourcemaps = require('gulp-sourcemaps');
var sync = require('gulp-sync')(gulp);
var tslint = require('gulp-tslint');
var del = require('del');
var path = require('path');


gulp.task('clean-app', function () {
    return del([
        'app/**/*.js',
        'app/**/*.js.map',
    ]);
});

gulp.task('ts-transpile', function() {
    var tsProject = typescript
        .createProject('tsconfig.json');

    var tsResult = tsProject
        .src('./app/**/*.ts')
        .pipe(sourcemaps.init())
        .pipe(tsProject());
 
    return tsResult
        .js
        .pipe(sourcemaps.write('.', {destPath: './app'}))
        .pipe(gulp.dest('./app'));
});

// gulp.task('ts-transpile', function() {
//     var tsProject = typescript
//         .createProject('tsconfig.json');

//     var tsResult = tsProject
//         .src('./app/**/*.ts')
//         .pipe(sourcemaps.init())
//         .pipe(tsProject());
 
//     return tsResult
//         .js
//         .pipe(sourcemaps.write('.'))
//         .pipe(gulp.dest('./app'));
// });

gulp.task('ts-watch', ['ts-transpile'], function() {
    gulp.watch('./app/**/*.ts', ['ts-transpile']);
});

// Default task, if gulp is called without arguments
gulp.task('default', ['ts-watch']);