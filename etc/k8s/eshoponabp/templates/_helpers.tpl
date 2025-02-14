{{/*
Expand the name of the chart.
*/}}
{{- define "eshoponabp.name" -}}
{{- default .Chart.Name .Values.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Create a default fully qualified app name.
We truncate at 63 chars because some Kubernetes name fields are limited to this (by the DNS naming spec).
If release name contains chart name it will be used as a full name.
*/}}
{{- define "eshoponabp.fullname" -}}
{{- if .Values.fullnameOverride }}
{{- .Values.fullnameOverride | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- $name := default .Chart.Name .Values.nameOverride }}
{{- if contains $name .Release.Name }}
{{- .Release.Name | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" }}
{{- end }}
{{- end }}
{{- end }}

{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "eshoponabp.chart" -}}
{{- printf "%s-%s" .Chart.Name .Chart.Version | replace "+" "_" | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Common labels
*/}}
{{- define "eshoponabp.labels" -}}
helm.sh/chart: {{ include "eshoponabp.chart" . }}
{{ include "eshoponabp.selectorLabels" . }}
{{- if .Chart.AppVersion }}
app.kubernetes.io/version: {{ .Chart.AppVersion | quote }}
{{- end }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "eshoponabp.selectorLabels" -}}
app.kubernetes.io/name: {{ include "eshoponabp.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}

{{/*
Create the name of the service account to use
*/}}
{{- define "eshoponabp.serviceAccountName" -}}
{{- if .Values.serviceAccount.create }}
{{- default (include "eshoponabp.fullname" .) .Values.serviceAccount.name }}
{{- else }}
{{- default "default" .Values.serviceAccount.name }}
{{- end }}
{{- end }}

{{- define "eshoponabp.global.env" -}}
- name: "DOTNET_ENVIRONMENT"
  value: "{{ .Values.global.dotnetEnvironment }}"
- name: "AppUrls__ApiInternal"
  value: "{{ .Values.global.apiUrlInternal }}"
- name: "Redis__Configuration"
  value: "{{ .Values.global.redisConfiguration }}"
- name: "AuthServer__Authority"
  value: "{{ .Values.global.internalAuthServerAuthority }}"
- name: "AuthServer__RequireHttpsMetadata"
  value: "{{ .Values.global.internalAuthServerRequireHttpsMetadata }}"
- name: "StringEncryption__DefaultPassPhrase"
  value: "{{ .Values.global.stringEncryptionDefaultPassPhrase }}"
- name: "RabbitMQ__Connections__Default__HostName"
  value: "{{ .Values.global.rabbitMqHostName }}"  
{{- end }}
