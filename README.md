# CivicConnect

## Purpose
CivicConnect is a platform designed to streamline municipal issue reporting, tracking, and resolution. This repository contains the Milestone 2 codebase, demonstrating our established N-Tier architecture, initial SQL Server persistence model, and foundational API components.

## Team
* **Bernu du Plessis**
* **Rodney Mlotshwa**

## Current Implementation Status (Milestone 2 Baseline)
* **Architecture:** N-Tier Layered Monolith established (`CivicConnect.Api`, `CivicConnect.Core`, `CivicConnect.Infrastructure`).
* **Persistence:** Entity Framework Core configuration and initial database schema baselined.
* **API:** RESTful endpoints scaffolded for ticket intake and status management.
* **Security:** User Secrets configured; no hardcoded credentials in source control.
* **Governance:** Protected `main` branch enforcing a minimum of 1 independent peer review per Pull Request (approved 2-person team exemption).

## Technology & Runtime Versions
* **SDK:** .NET 10.0 (C#)
* **ORM:** Entity Framework Core 10.0
* **Database Engine:** LocalDB (SQL Server) / In-Memory Bootstrap
* **CI/CD:** GitHub Actions (ubuntu-latest)

## Prerequisites
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) installed locally.
* Git version control.
* Visual Studio 2022 or Visual Studio Code.

