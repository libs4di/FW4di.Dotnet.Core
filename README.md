# FW4di.Dotnet.Core

Core library of the 4di framework targeting .NET.

## 📦 Overview

**FW4di.Dotnet.Core** provides the foundational components of the 4di framework for .NET applications.  
It contains essential building blocks and abstractions used across other 4di libraries and modules.

## 🧩 Modules

### 🔧 DependencyInjection
Provides tools and extensions for dependency injection and service registration, enabling a clean, modular, and testable architecture.
This module offers an abstraction layer over multiple DI containers — by default, it uses Ninject, but you can easily replace it with your preferred provider.
The DIManager acts as the main entry point for dependency management and can be seamlessly integrated with other framework components (like Mocking and Mapping).

### 💾 IO
Contains utilities for XML-based input/output operations.

#### `XmlHelper`
The `XmlHelper` class provides simple methods for XML serialization and deserialization of .NET objects.

### 🔀 Mapping
Provides lightweight and flexible object-to-object mapping utilities.
It supports both convention-based and manually configured mappings to transform objects between different models.
This module acts as a wrapper around AutoMapper, simplifying the setup and integration process.
Mappings can be registered via a MappingList, which collects and organizes all mapping profiles used throughout the application.

### 🧪 Mocking

Offers a minimal and extensible mocking framework for creating test doubles and mock implementations.
The module integrates seamlessly with the dependency injection system, allowing you to easily replace real implementations with mocks during testing.
This component provides a lightweight abstraction over Moq, ensuring consistent mock generation across the framework.