# SoftTest-Stresstest-CarApi

## LoadEmulationOptions

| Option | Description | Default value | Environment Variable (Docker) |
| ----------- | ----------- | ------- | ---- | 
| Enable | Enables Loademulation | False | LEoptions__Enable |
| MaxRequests | Maximum size of the TokenBucket. | 100 | LEoptions__MaxRequests |
| RequestRefillAmount | Amount to refill the bucket when the timer elapses. | 10 | LEoptions__RequestRefillAmount |
|RequestRefillRateMs| Refill rate in ms. the time it will refill the bucket. | 5000 | LEoptions__RequestRefillRateMs |