# Blazor WebAssembly with TypeScript Integration

This repository contains a simple example of how to integrate **TypeScript** into a **.NET 10 Blazor WebAssembly** application. It demonstrates the interoperability between C# (Blazor) and JavaScript (compiled from TypeScript).

## 🚀 About the Project

In modern web development, you often need to use specific JavaScript libraries or browser APIs that aren't natively exposed in Blazor. This project shows a clean pattern for doing so:
1.  Writing logic in **TypeScript** for type safety and modern tooling.
2.  Compiling it to **JavaScript**.
3.  Invoking it from **C#** using Blazor's `IJSRuntime`.

## 📂 Project Structure

Here is a quick overview of the key files in the solution:

- **`BlazorApp.csproj`**: The project file. It targets **.NET 10** (`net10.0`).
- **`Program.cs`**: The entry point. Configures services like `HttpClient` and the root components.
- **`Pages/Index.razor`**: The main UI page. It contains a button that calls a C# method, which in turn calls JavaScript.
- **`src/example.ts`**: The source TypeScript file. This is where the client-side logic lives.
- **`wwwroot/js/example.js`**: The compiled JavaScript artifact that the browser actually runs.
- **`wwwroot/index.html`**: The host HTML page. It loads both the Blazor runtime and our custom script.
- **`tsconfig.json`**: Configuration for the TypeScript compiler (sets output directory to `wwwroot/js`).

## 🛠 Prerequisites

To run this project, you need:
- **.NET 10.0 SDK** (or newer)
- **Node.js & npm** (optional, only needed if you want to modify and recompile the TypeScript code)

## ⚡ How to Run

1.  **Navigate to the project directory**:
    ```bash
    cd c:/Projects/blazor-typescript
    ```

2.  **Run the application**:
    ```bash
    dotnet run
    ```

3.  **View in Browser**:
    Open the URL displayed in the terminal (e.g., `http://localhost:5000`).

4.  **Test the Interop**:
    Click the **"Click me"** button on the home page. You should see a browser alert saying "Hello from Blazor!".

## 📝 How It Works

### 1. TypeScript (`src/example.ts`)
We define a function `showAlert` and attach it to the global `window` object under a namespace `example`.
```typescript
const showAlert = (message: string): void => {
    alert(message);
};
(window as any).example = { showAlert };
```

### 2. Loading the Script (`wwwroot/index.html`)
We simply include the compiled file in the HTML body:
```html
<script src="js/example.js"></script>
```

### 3. C# Invocation (`Pages/Index.razor`)
We inject the `IJSRuntime` service and call the function using its global name:
```csharp
@inject IJSRuntime JS

private async Task CallTsFunction()
{
    await JS.InvokeVoidAsync("example.showAlert", "Hello from Blazor!");
}
```

## 🔄 Development Workflow

The project is configured to **automatically build** the TypeScript code whenever you run the .NET project.

1.  Modify `src/example.ts`.
2.  Run `dotnet run` (or `dotnet build`).
3.  Reload the browser.

The `.csproj` file handles checking for `node_modules` and running the TypeScript compiler for you.
