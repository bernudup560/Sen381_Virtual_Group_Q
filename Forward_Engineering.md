This document identifies project-specific later lifecycle concerns that require attention now, without prematurely implementing or deciding them.
1. Database Indexing and Performance
•	Why it matters now: The PED mandates a strict sub-2.0 second response time at the 95th percentile under 50 concurrent virtual users. 
•	What it influences: Future database schema design and the mandatory addition of database indexing on frequently searched columns (Status, CategoryID, TrackingID). 
•	Missing Information: The specific relational complexity required for the finalized Milestone 2 data model.
•	Risk of Ignoring It: Unindexed database queries will fail performance checks as the ticket volume grows. 
2. Centralized RBAC Security Middleware
•	Why it matters now: The system requires multi-tenant role separation (Requester, Staff, Management). Relying on UI-level view hiding is insufficient and insecure. 
•	What it influences: Implementing centralized RBAC middleware at the API routing layer to validate JWT or session cookies. 
•	Missing Information: Which specific authentication library will be used in Milestone 2.
•	Risk of Ignoring It: Unauthorized API calls targeting staff or management endpoints could expose citizen data. 
3. Automated Testability and Quality Assurance
•	Why it matters now: Requirements must be written with testable acceptance criteria now (e.g., SLA > 48 hours calculation) so automated test suites can be built later. 
•	What it influences: Architecture patterns and choice of testing frameworks.
•	Missing Information: The specific testing tools or CI/CD pipelines mandated for Milestone 2.
•	Risk of Ignoring It: Writing untestable code that requires manual verification for every bug fix.
