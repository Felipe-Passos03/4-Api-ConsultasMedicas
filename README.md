# 🏥 API – Consultas Médicas

## 📌 Objetivo
Desenvolver um sistema de agendamento de consultas médicas com regras de negócio que garantam integridade, segurança e controle de acesso.

---

## ✅ Regras de Negócio

### 🗓️ Agendamento
1. **Sem conflitos de horário:** O médico não pode ter dois agendamentos no mesmo horário.
2. **Sem consultas no passado:** Consultas não podem ser agendadas para datas passadas.
3. **Consulta única por dia:** Um paciente pode ter apenas uma consulta com o mesmo médico no mesmo dia.
4. **Dias úteis apenas:** Consultas só podem ser marcadas de segunda a sexta.
5. **Médicos ativos:** Médicos inativos não podem receber novos agendamentos.
6. **Pacientes adimplentes:** Pacientes inadimplentes não podem agendar.
7. **Sem reagendamento:** Para alterar a consulta, é necessário cancelar e agendar uma nova.

### ❌ Cancelamento
9. **Antecedência mínima:** O paciente só pode cancelar uma consulta com no mínimo 24h de antecedência.
10. **Status correto:** Só é permitido cancelar se a consulta estiver com status “Agendada”.
11. **Registro de cancelamento:** O sistema deve registrar data/hora e motivo do cancelamento.

### 🔒 Restrições de Acesso e Alterações
12. **Privacidade médica:** Um médico pode visualizar apenas as suas consultas.
13. **Privacidade do paciente:** Um paciente pode visualizar apenas as próprias consultas.
14. **Imutável após finalização:** Após a finalização, a consulta não pode mais ser alterada.
15. **Finalização correta:** Consultas só podem ser finalizadas após a data/hora agendada.

---

## 💡 Observação
Essas regras garantem a integridade do sistema, evitam conflitos de agendamento, e asseguram que cada perfil (médico ou paciente) tenha acesso apenas ao que lhe compete.
