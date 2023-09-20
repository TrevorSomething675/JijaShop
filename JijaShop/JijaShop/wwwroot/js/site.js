// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var wasmHelper = {};

wasmHelper.ACCESS_TOKEN_KEY = "__access_token__";

wasmHelper.saveAccessToken = function (tokenStr) {
    localStorage.setItem(wasmHelper.ACCESS_TOKEN_KEY, tokenStr);
};

wasmHelper.getAccessToken = function () {
    return localStorage.getItem(wasmHelper.ACCESS_TOKEN_KEY);
};