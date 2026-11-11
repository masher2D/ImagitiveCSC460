# Imagitive — Your Personal Museum

A C# WinForms image-sharing platform that lets local artists showcase their work without the threat of AI theft or algorithm suppression.

## Overview

Local artists struggle to get exposure: social media algorithms filter them out, AI-generated content floods feeds, and platforms train on (and resell) artists' work without credit. Imagitive gives artists a safe, local-first space to share art, with guaranteed visibility per upload and protections against unauthorized copying.

## Features

**Viewers**
- Browse an artist's full portfolio via profile search
- Discover a random stream of artworks (region-weighted, fair-impression queue)
- Rate artworks and report content that breaks terms of service
- Download watermarked, reduced-resolution copies

**Artists**
- Upload and delete images in a personal portfolio
- Tag artworks with preset descriptors

**Admins**
- Review reported content and act (remove artwork, warn, suspend, ban)
- Manage user accounts (restrict posting, ban/unban)

## Tech Stack

- **UI:** C# WinForms (.NET)
- **Database:** Microsoft SQL Server
- **Data Access:** EF Core combined with SQL Stored Procedures
- **API** ASP.NET Core Web API
- **Auth** JWT Bearer, BCrypt
- **Image Handling:** Server-side watermarking, reduced-resolution display


