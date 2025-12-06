/**
 * This file contains the TypeScript logic for the application.
 * It is compiled into JavaScript (wwwroot/js/example.js) and loaded in index.html.
 */

/**
 * A simple function to demonstrate calling JS from Blazor.
 * @param message The message to display in the alert.
 */
const showAlert = (message: string): void => {
    // Standard browser alert
    alert(message);

    // Log to the browser console for debugging
    console.log("Logged from TypeScript:", message);
};

// ==================================================================================
// EXPOSING TO GLOBAL SCOPE
// ==================================================================================
// Blazor WebAssembly (in this simple setup) looks for functions on the global 'window' object.
// We assign our functions to a namespace object 'example' on 'window'.
// casting to 'any' is necessary because 'window' doesn't normally have an 'example' property.
(window as any).example = {
    showAlert
};
