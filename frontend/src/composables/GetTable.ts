import { ref, onMounted } from 'vue'
import axios from 'axios'
import { apiUrl } from './ApiUrl'

interface TableResponseDto {
    pid: number
    name: string
    type: string
    age: number
}

export const useGetTables = () => {
    const datas = ref<TableResponseDto[]>([])

    const getTables = async () => {
        const res = await axios.get(`${apiUrl}/table`)
        datas.value = res.data
    }

    onMounted(getTables)

    return { datas }
}