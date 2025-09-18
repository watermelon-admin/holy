# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**BreakScreen** (codename: holy) - A break timer application for online and offline events, courses, and workshops.

### Application Purpose
BreakScreen helps instructors manage and display break timers during events. Key features include:
- Customizable break types (Coffee Break, Lunch Break, Lab Break, etc.)
- Full HD background images and icons for each break type
- Countdown timer display with multi-timezone support
- QR code generation for mobile timer access
- Mobile-friendly companion view for attendees

## Technology Stack

### Core Technologies
- **IDE**: Visual Studio Core
- **Framework**: ASP.NET Core 9 Web App with Razor Pages (no MVC)
- **Client-side**: TypeScript
- **Authentication**: ASP.NET Core Identity with Azure Tables via ElCamino.AspNetCore.Identity.AzureTable
  - Documentation: https://elcamino.cloud/projects/docs/identityazuretable/gettingstarted.html
- **Data Storage**: Azure Tables

## Application Architecture

### Key Components

1. **Instructor Interface**
   - Start Break screen with break type selection
   - Break duration configuration
   - Break type management (create/edit/delete)

2. **Break Type Configuration**
   - Name (e.g., "Coffee Break", "Lunch Break", "Lab Break")
   - Default duration
   - Full HD background image
   - Icon

3. **Break Display Screen**
   - Break name
   - Countdown timer
   - End times for multiple time zones (configurable)
   - QR code for mobile access

4. **Mobile Companion View**
   - Simple interface accessed via QR code
   - Displays break name and countdown timer
   - Allows attendees to carry the timer with them

## Development Workflow

### GitHub Flow
Follow GitHub Flow for all development:
1. Create a feature branch from `main` for each new feature or fix
2. Make commits to the feature branch
3. Open a Pull Request when ready for review
4. After review and approval, merge to `main`
5. Deploy from `main` branch

### Development Commands

```bash
# Build the solution
dotnet build

# Run the application
dotnet run

# Run tests
dotnet test

# Watch for changes during development
dotnet watch run
```

## Azure Tables Configuration

The application uses Azure Tables for:
- ASP.NET Core Identity storage (users, roles, claims)
- Application data (break types, settings, timezone configurations)

## Notes

- Uses Razor Pages architecture (not MVC)
- TypeScript compilation should be configured for client-side code
- Background images should be optimized for Full HD display (1920x1080)
- QR codes should be generated dynamically for each break session