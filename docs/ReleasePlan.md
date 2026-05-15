# Release Plan

## Steps
1. Code freeze
2. Run full test suite
3. Deploy to staging
4. Smoke test
5. Deploy to production

## Deployment
- API → Azure App Service or VM
- UI → Static hosting (Nginx/Azure Static Web Apps)
- DB → Azure SQL

## Configuration
- Environment variables set
- Connection strings secured

## Monitoring
- Application logs
- Error tracking

## Post-release check
- Endpoint availability
- UI functionality