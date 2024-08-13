# Using Semi-Structured Data with JSON Columns in Entity Framework Core

This repo is about using semi-structured data for specific features in projects that typically use structured data.

To address this, the JSON column type in Entity Framework Core can be utilized. Many relational databases support JSON columns, enabling queries to filter, sort, and project elements from JSON documents. This hybrid approach combines relational and document database features.

EF7 offers provider-agnostic support for JSON columns, including an implementation for SQL Server, allowing mapping of .NET types to JSON documents and translating LINQ queries to JSON-specific queries, including updates and saving changes.
