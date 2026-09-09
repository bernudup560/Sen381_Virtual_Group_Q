This document traces the baselined functional and non-functional requirements back to their originating stakeholders and architectural constraints to ensure all engineering efforts deliver confirmed business value.
FR-001: Categorized Request Intake
•	Requirement Type: Functional
•	Stakeholder: Requester Stakeholder Group 
•	Priority: High 
•	Traceability Justification: Addresses the community's need for a simple intake form with mandatory category dropdowns to log service requests. 
•	Status: Baselined in Milestone 1
FR-002: Workflow Status Transitions
•	Requirement Type: Functional
•	Stakeholder: Field Staff Stakeholder Group 
•	Priority: High 
•	Traceability Justification: Allows staff to transition a request's state (Open to In Progress or Resolved) to maintain full lifecycle visibility and accountability. 
•	Status: Baselined in Milestone 1
FR-003: Overdue Task Analytics
•	Requirement Type: Functional
•	Stakeholder: Executive Management Stakeholder Group 
•	Priority: Medium 
•	Traceability Justification: Provides management with summary reports highlighting requests that have exceeded the 48-hour SLA timeline for oversight. 
•	Status: Baselined in Milestone 1
NFR-001: Query Performance & Response Latency
•	Requirement Type: Non-Functional
•	Source / Constraint: System Quality Attribute / Architectural Guardrail 
•	Priority: High 
•	Traceability Justification: Ensures the application backend maintains sub-2-second response times under standard loads to prevent system redundancy and waste. 
•	Status: Baselined in Milestone 1
NFR-002: Role-Based Authorization Enforcement
•	Requirement Type: Non-Functional
•	Source / Constraint: System Security Architecture 
•	Priority: High 
•	Traceability Justification: Enforces server-side authorization checks to secure the multi-tenant role separation (Requester, Staff, Management) using middleware. 
•	Status: Baselined in Milestone 1

