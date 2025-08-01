"use client"

import { Bar, BarChart, CartesianGrid, LabelList, XAxis, YAxis } from "recharts"
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card"
import {
  ChartContainer,
  ChartTooltip,
  ChartTooltipContent,
} from "@/components/ui/chart"
import { AdminDashPositiveModel } from "@/app/(models)/(admin)/admin-dash-positive.model"

interface Props {
  model: AdminDashPositiveModel
}

export function AdminDashPositive(props: Props) {
  return (
    <Card className="w-sm">
      <CardHeader>
        <CardTitle>Produtos mais positivos</CardTitle>
        <CardDescription>Ano de 2025</CardDescription>
      </CardHeader>
      <CardContent>
        <ChartContainer config={props.model.chartConfig}>
          <BarChart
            accessibilityLayer
            data={props.model.chartData}
            layout="vertical"
            margin={{
              right: 16,
            }}
          >
            <CartesianGrid horizontal={false} />
            <YAxis
              dataKey="type"
              type="category"
              tickLine={false}
              tickMargin={10}
              axisLine={false}
              tickFormatter={(value) => value.slice(0, 3)}
              hide
            />
            <XAxis dataKey="count" type="number" hide />
            <ChartTooltip
              cursor={false}
              content={<ChartTooltipContent indicator="line" />}
            />
            <Bar
              dataKey="count"
              fill="var(--color-count)"
              radius={4}
            >
              <LabelList
                dataKey="type"
                position="insideLeft"
                offset={8}
                className="fill-(--color-label)"
                fontSize={12}
              />
              <LabelList
                dataKey="count"
                position="right"
                offset={8}
                className="fill-foreground"
                fontSize={12}
              />
            </Bar>
          </BarChart>
        </ChartContainer>
      </CardContent>
      <CardFooter className="flex-col items-start gap-2 text-sm">
        <div className="text-muted-foreground leading-none">
          {
            props.model.chartData?.length > 0
            ? "Baseado no total de comentários até o momento"
            : "Nenhuma informação foi coletada até o momento"
          }
        </div>
      </CardFooter>
    </Card>
  )
}