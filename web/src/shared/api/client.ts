// Ponto único de acesso HTTP à API. Toda chamada ao back passa por aqui.
export async function apiGet<T>(path: string): Promise<T> {
  const response = await fetch(`/api${path}`)
  if (!response.ok) {
    throw new Error(`Erro ${response.status} ao chamar ${path}`)
  }
  return response.json() as Promise<T>
}
