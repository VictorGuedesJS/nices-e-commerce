import { useEffect, useState } from 'react'
import { apiGet } from './shared/api/client'

type Health = { status: string; horario: string }

type Estado =
  | { tipo: 'carregando' }
  | { tipo: 'online'; dados: Health }
  | { tipo: 'offline'; erro: string }

export default function App() {
  const [estado, setEstado] = useState<Estado>({ tipo: 'carregando' })

  useEffect(() => {
    apiGet<Health>('/health')
      .then((dados) => setEstado({ tipo: 'online', dados }))
      .catch((e: Error) => setEstado({ tipo: 'offline', erro: e.message }))
  }, [])

  return (
    <main className="min-h-screen bg-neutral-50 flex flex-col items-center justify-center gap-4 p-4">
      <h1 className="text-4xl font-bold tracking-tight text-neutral-900">Loja</h1>
      {estado.tipo === 'carregando' && <p className="text-neutral-500">Verificando API…</p>}
      {estado.tipo === 'online' && (
        <p className="rounded-full bg-green-100 px-4 py-1 text-green-800">
          API online ✅ ({new Date(estado.dados.horario).toLocaleTimeString('pt-BR')})
        </p>
      )}
      {estado.tipo === 'offline' && (
        <p className="rounded-full bg-red-100 px-4 py-1 text-red-800">
          API offline ❌ ({estado.erro})
        </p>
      )}
    </main>
  )
}
