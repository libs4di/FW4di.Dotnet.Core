# FW4di.Dotnet.Core

Core library of the 4di framework targeting .NET.

## 📦 Overview

**FW4di.Dotnet.Core** provides the foundational components of the 4di framework for .NET applications.  
It contains essential building blocks and abstractions used across other 4di libraries and modules.

## 🧩 Modules

### 🔧 DependencyInjection
Provides tools and extensions for dependency injection and service registration, enabling a clean and modular architecture.

### 💾 IO
Contains utilities for XML-based input/output operations.

#### `XmlHelper`
The `XmlHelper` class provides simple methods for XML serialization and deserialization of .NET objects.

### 🔀 Mapping
Provides lightweight and flexible object-to-object mapping utilities.  
It supports both convention-based and manually configured mappings to transform objects between different models.

### 🧪 Mocking

Offers a minimal and extensible mocking framework for creating test doubles and mock implementations.
The module integrates with the dependency injection system, making it easy to replace real implementations with mocks during testing.