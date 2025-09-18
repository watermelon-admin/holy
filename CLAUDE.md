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

### GitHub Flow with Issue Tracking
Follow GitHub Flow for all development:
1. Create a GitHub issue for each feature, bug, or task
2. Create a feature branch from `main` named with the issue number and description (e.g., `issue-123-add-timer-component`)
3. **MANDATORY**: Every commit MUST link to the relevant issue using `#123` in commit messages
4. **MANDATORY**: Every commit MUST include "Closes #123", "Fixes #123", or "Resolves #123" to automatically close the issue
5. Open a Pull Request linked to the issue when ready for review
6. Reference the issue in PR title and description (e.g., "Fixes #123: Add timer component")
7. After review and approval, merge to `main`
8. The issue will automatically close when the PR is merged due to the commit message linking
9. Deploy from `main` branch

### Commit Message Requirements
**CRITICAL**: Every commit must reference an issue. Format:
```
Brief description of changes

- Detailed bullet points of what was implemented
- Include technical details and rationale

Closes #123

🤖 Generated with [Claude Code](https://claude.ai/code)

Co-Authored-By: Claude <noreply@anthropic.com>
```

**Example commit messages:**
- ✅ `Add timer component with countdown functionality\n\nCloses #123`
- ✅ `Fix timezone calculation bug in break display\n\nResolves #45`
- ❌ `Update timer component` (missing issue reference)
- ❌ `Various bug fixes` (missing issue reference)

### Branch Naming Convention
- Format: `issue-{number}-{brief-description}`
- Examples:
  - `issue-42-add-break-types`
  - `issue-101-fix-timer-bug`
  - `issue-88-azure-tables-setup`

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