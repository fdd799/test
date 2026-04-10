import { ref, onMounted } from 'vue'
import axios from 'axios'

interface TableResponseDto {
    pid: number
    name: string
    type: string
    age: number
}

export const useGetTables = () => {
    const apiUrl = import.meta.env.VITE_API_URL

    const datas = ref<TableResponseDto[]>([])

    const getTables = async () => {
        const res = await axios.get(`${apiUrl}/table`)
        datas.value = res.data
    }

    onMounted(getTables)

    return { datas }
}